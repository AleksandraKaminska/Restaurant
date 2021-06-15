import React, {useState} from 'react';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import { ORDERS_API_URL} from '../../constants';
import {Redirect} from "react-router-dom";
import './Orders.css';

const NewOrder: React.FC<{}> = () => {
    const [submitted, setSubmitted] = useState<boolean>(false);
    
    if (submitted) {
        return <Redirect to='/orders' />
    }
    
    return (
      <div>
        <h1>Add a new order</h1>
        <Formik
          initialValues={{
            status: 0
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
                    waiterId: 1
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
