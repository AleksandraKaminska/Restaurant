import React, {useState} from 'react';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import { TABLES_API_URL} from '../../constants';
import {Redirect} from "react-router-dom";
import './Tables.css';

const NewTable: React.FC<{}> = () => {
    const [submitted, setSubmitted] = useState<boolean>(false);
    
    if (submitted) {
        return <Redirect to='/tables' />
    }
    
    return (
      <div>
        <h1>Add a new table</h1>
        <Formik
          initialValues={{
              status: 0,
              localId: null
          }}
          onSubmit={(values, { setSubmitting }) =>
          {
            fetch(TABLES_API_URL, {
                method: 'post',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    status: values.status,
                    localId: values.localId
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

export default NewTable;
