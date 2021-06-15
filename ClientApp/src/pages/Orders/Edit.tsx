import React, { useEffect, useState } from 'react';
import {Redirect, useParams} from 'react-router-dom';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import { ORDERS_API_URL} from '../../constants';
import {Spinner} from "reactstrap";
import './Orders.css';

const EditOrder: React.FC<{}> = () => {
    let { id } = useParams<{ id: string }>();
    const [order, setOrder] = useState<any>(null);
    const [submitted, setSubmitted] = useState<boolean>(false);

    useEffect(() => {
      fetchOrder().then(order => setOrder(order))
    }, [])

    const fetchOrder = async () => {
        const response = await fetch(`${ORDERS_API_URL}/${id}`)
        return await response.json()
    }
    
    if (submitted) {
        return <Redirect to='/orders' />
    }

    return order ? (
      <div>
        <h1>Edit a order</h1>
        <Formik
          initialValues={{
            status: order.status
          }}
          onSubmit={(values, { setSubmitting }) =>
          {
            fetch(`${ORDERS_API_URL}/${id}`, {
                method: 'put',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    status: values.status
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
          {({ isSubmitting, errors }) => (
            <Form>
              <div className={`form-group ${errors.status && 'has-error'}`}>
                  <label htmlFor="status">Status *</label>
                  <Field as="select" name="status" className="form-control">
                      <option value="0">Received</option>
                      <option value="1">In preperation</option>
                      <option value="2">Done</option>
                  </Field>
                  <ErrorMessage name="status" component="div" />
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
    ) : <Spinner type="primary" />
}

export default EditOrder;
