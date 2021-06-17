import React, {useEffect, useState} from 'react';
import {useLocation, Link, Redirect, useParams} from "react-router-dom";
import {Button, ListGroup, ListGroupItem, Spinner} from "reactstrap";
import {Order} from "./Orders";
import {MenuItem} from "../Menu/Menu";
import {BILLS_API_URL, ORDER_MENU_ITEMS_API_URL, ORDERS_API_URL, TABLES_API_URL} from "../../constants";
import './Orders.css';
import {ErrorMessage, Field, Form, Formik} from "formik";

export type OrderMenuItem = {
    quantity: number
    id: number
    menuItem: MenuItem
}

type OrderSummaryProps = {
}

const Payment: React.FC<OrderSummaryProps> = () => {
    let { id } = useParams<{ id: string }>();
    const [submitted, setSubmitted] = useState<boolean>(false);
    const [order, setOrder] = useState<any>(null);
    const [loading, setLoading] = useState<boolean>(false)
    const orderTotal = order?.orderMenuItems.reduce((prev: number, orderMenuItem: OrderMenuItem) =>
        prev + orderMenuItem.menuItem.price * orderMenuItem.quantity, 0)
    
    useEffect(() => {
        const fetchOrder = async () => {
            setLoading(true)
            const response = await fetch(`${ORDERS_API_URL}/${id}`)
            const resp =  await response.json()
            setLoading(false)
            return resp
        }

        fetchOrder().then(order => {
            setOrder(order)
        })
    }, [id])

    if (submitted) {
        return <Redirect to='/orders' />
    }

    return loading ? <Spinner type='primary' /> : (
        <div className='mt-4 ml-5 pl-4 d-flex flex-column justify-content-between'>
            <h1>Choose payment</h1>
            <Formik
                initialValues={{
                    tip: 0,
                    paymentMethod: 0
                }}
                onSubmit={(values, { setSubmitting }) =>
                {
                    fetch(BILLS_API_URL, {
                        method: 'post',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify({
                            tip: values.tip,
                            paymentMethod: values.paymentMethod
                        })
                    })
                        .then(res => {
                            setSubmitted(true)
                            return res.json()
                        })
                        .catch(err => console.log(err));

                    setSubmitting(false);
                }}
            >
                {({ isSubmitting, errors, values }) => (
                    <Form>
                        <p className='mt-4 mb-5'><b>Total amount:</b> {orderTotal + values.tip} zł</p>
                        <div className={`form-group ${errors.tip && 'has-error'}`}>
                            <label htmlFor="tip">Tip</label>
                            <Field type="number" name="tip" className="form-control" />
                            <ErrorMessage name="tip" component="div" />
                        </div>
                        <div className={`form-group ${errors.paymentMethod && 'has-error'}`}>
                            <label htmlFor="paymentMethod">Payment method *</label>
                            <Field as="select" name="paymentMethod" className="form-control">
                                <option value="0">Cash</option>
                                <option value="1">Creadit card</option>
                            </Field>
                            <ErrorMessage name="paymentMethod" component="div" />
                        </div>
                        <div className="form-group">
                            <button type="submit" disabled={isSubmitting} className="btn btn-primary">
                                Submit
                            </button>
                        </div>
                    </Form>
                )}
            </Formik>
        </div>
    )
}

export default Payment;
