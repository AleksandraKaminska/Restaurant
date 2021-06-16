import React, {useEffect, useState} from 'react';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import {LOCALS_API_URL, TABLES_API_URL} from '../../constants';
import {Redirect} from "react-router-dom";
import './Tables.css';
import {Local} from "../Locals/Locals";

const NewTable: React.FC<{}> = () => {
    const [submitted, setSubmitted] = useState<boolean>(false);
    const [locals, setLocals] = useState<Array<Local>>([]);
    const [loading, setLoading] = useState<boolean>(false)
    
    useEffect(() => {
        fetchAllLocals().then(locals => setLocals(locals))
    }, [])

    const fetchAllLocals = async () => {
        setLoading(true)
        const response = await fetch(LOCALS_API_URL)
        const resp = await response.json()
        setLoading(false)
        return resp
    }
    
    if (submitted) {
        return <Redirect to='/tables' />
    }
    
    return (
      <div>
        <h1>Add a new table</h1>
        <Formik
          initialValues={{
              status: 0,
              nrOfSeats: 0,
              localId: 1
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
                    nrOfSeats: values.nrOfSeats,
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
                <div className={`form-group ${errors.status && 'has-error'}`}>
                    <label htmlFor="localId">Local *</label>
                    <Field as="select" name="localId" className="form-control">
                        {locals.map(local => 
                            <option key={local.id} value={local.id}>
                                {local.address.street} {local.address.apartmentNumber}, {local.address.city}
                            </option>
                        )}
                    </Field>
                    <ErrorMessage name="localId" component="div" />
                </div>
                <div className={`form-group ${errors.nrOfSeats && 'has-error'}`}>
                    <label htmlFor="nrOfSeats">Number of seats *</label>
                    <Field type="number" name="nrOfSeats" className="form-control" />
                    <ErrorMessage name="nrOfSeats" component="div" />
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

export default NewTable;
