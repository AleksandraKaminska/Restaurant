import React, {useEffect, useState} from 'react';
import {Field, Form, Formik} from 'formik';
import {ORDERS_API_URL, TABLES_API_URL} from '../../constants';
import {Redirect} from "react-router-dom";
import {getStatusName, StatusType, Table} from "../Tables/Tables";
import {Card, CardBody, CardSubtitle, CardText, CardTitle, Spinner} from "reactstrap";
import {Order} from "./Orders";
import './Orders.css';

const NewOrder: React.FC<{}> = () => {
    const [submitted, setSubmitted] = useState<boolean>(false);
    const [tables, setTables] = useState<Array<Table>>([]);
    const [loading, setLoading] = useState<boolean>(false)
    const [order, setOrder] = useState<Order>();

    useEffect(() => {
        fetchAllTables().then(tables => setTables(tables))
    }, [])

    const fetchAllTables = async () => {
        setLoading(true)
        const response = await fetch(TABLES_API_URL)
        const resp = await response.json()
        setLoading(false)
        return resp
    }
    
    if (submitted && order) {
        return <Redirect to={`/orders/${order.id}/edit`} />
    }
    
    return loading ? <Spinner type='primary'/> : (
      <div>
        <h1>Add a new order</h1>
        <Formik
          initialValues={{
              status: 0,
              tableId: 0
          }}
          onSubmit={(values, { setSubmitting }) =>
          {
            fetch(ORDERS_API_URL, {
                method: 'post',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    status: values.status,
                    tableId: values.tableId
                })
            })
            .then(res => {
                setSubmitted(true)
                return res.json()
            }).then(data => setOrder(data))
            .catch(err => console.log(err));

            setSubmitting(false);
          }}
        >
          {({ isSubmitting, errors }) => (
            <Form>
                <div role="group d-flex flex-wrap">
                    {tables.map((table: Table) =>
                        <label key={table.id} className={`m-3 ${table.status === StatusType.Occupied ? 'disabled' : 'pointer'}`}>
                            <Field type="radio" disabled={table.status === StatusType.Occupied} className='d-none' name="tableId" value={table.id.toString()} />
                            <Card color={table.status === StatusType.Occupied ? 'light' : ''}>
                                <CardBody>
                                    <CardTitle tag="h5">Table {table.id}</CardTitle>
                                    <CardSubtitle tag="h6" className="mb-2 text-muted">Number of seats: {table.nrOfSeats}</CardSubtitle>
                                    <CardText>{getStatusName(table.status)}</CardText>
                                </CardBody>
                            </Card>
                        </label>
                    )}
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

export default NewOrder;
