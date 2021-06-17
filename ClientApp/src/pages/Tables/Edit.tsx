import React, { useEffect, useState } from 'react';
import {Redirect, useParams} from 'react-router-dom';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import { TABLES_API_URL} from '../../constants';
import { Spinner } from "reactstrap";
import './Tables.css';

const EditTable: React.FC<{}> = () => {
    let { id } = useParams<{ id: string }>();
    const [table, setTable] = useState<any>(null);
    const [submitted, setSubmitted] = useState<boolean>(false);

    useEffect(() => {
        const fetchTable = async () => {
            const response = await fetch(`${TABLES_API_URL}/${id}`)
            return await response.json()
        }
        
        fetchTable().then(table => setTable(table))
    }, [id])

    
    
    if (submitted) {
        return <Redirect to='/tables' />
    }
    
    return table ? (
      <div>
        <h1>Edit a table</h1>
        <Formik
          initialValues={{
              status: table.status,
              localId: table.localId,
              nrOfSeats: table.nrOfSeats
          }}
          onSubmit={(values, { setSubmitting }) =>
          {
            fetch(`${TABLES_API_URL}/${id}`, {
                method: 'put',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    status: values.status,
                    localId: values.localId,
                    nrOfSeats: values.nrOfSeats
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
                <div className={`form-group ${errors.localId && 'has-error'}`}>
                    <label htmlFor="localId">Local *</label>
                    <Field type="text" name="localId" className="form-control" />
                    <ErrorMessage name="localId" component="div" />
                </div>
                <div className={`form-group ${errors.status && 'has-error'}`}>
                    <label htmlFor="status">Status *</label>
                    <Field as="select" name="status" className="form-control">
                        <option value="0">Free</option>
                        <option value="1">Occupied</option>
                        <option value="2">Reserved</option>
                    </Field>
                    <ErrorMessage name="status" component="div" />
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
    ) : <Spinner type="primary" />
}

export default EditTable;
