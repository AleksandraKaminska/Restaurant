import React, { useEffect, useState } from 'react';
import {Redirect, useParams} from 'react-router-dom';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import { LOCALS_API_URL } from '../../constants';
import './Orders.css';

const EditLocal: React.FC<{}> = () => {
    let { id } = useParams<{ id: string }>();
    const [local, setLocal] = useState<any>(null);
    const [submitted, setSubmitted] = useState<boolean>(false);

    useEffect(() => {
      fetchLocal().then(local => setLocal(local))
    }, [])

    const fetchLocal = async () => {
        const response = await fetch(`${LOCALS_API_URL}/${id}`)
        return await response.json()
    }
    
    if (submitted) {
        return <Redirect to='/locals' />
    }

    return local ? (
      <div>
        <h1>Edit a local</h1>
        <Formik
          initialValues={{
            address: { street: local.address.street, apartmentNumber: local.address.apartmentNumber, city: local.address.city, zipCode: local.address.zipCode },
            nrOfTables: local.nrOfTables
          }}
          onSubmit={(values, { setSubmitting }) =>
          {
            fetch(`${LOCALS_API_URL}/${id}`, {
                method: 'put',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    address: values.address,
                    nrOfTables: values.nrOfTables
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
              <div className={`form-group ${errors.address?.street && 'has-error'}`}>
                <label htmlFor="address.street">Street *</label>
                <Field type="text" name="address.street" className="form-control" />
                <ErrorMessage name="address.street" component="div" />
              </div>
              <div className={`form-group ${errors.address?.apartmentNumber && 'has-error'}`}>
                <label htmlFor="address.apartmentNumber">Apartment number</label>
                <Field type="text" name="address.apartmentNumber" className="form-control" />
                <ErrorMessage name="address.apartmentNumber" component="div" />
              </div>
              <div className={`form-group ${errors.address?.city && 'has-error'}`}>
                <label htmlFor="address.city">City *</label>
                <Field type="text" name="address.city" className="form-control" />
                <ErrorMessage name="address.city" component="div" />
              </div>
              <div className={`form-group ${errors.address?.zipCode && 'has-error'}`}>
                <label htmlFor="address.zipCode">Zip code *</label>
                <Field type="text" name="address.zipCode" className="form-control" />
                <ErrorMessage name="address.zipCode" component="div" />
              </div>
              <div className={`form-group ${errors.nrOfTables && 'has-error'}`}>
                <label htmlFor="nrOfTables">Number of tables *</label>
                <Field type="number" name="nrOfTables" className="form-control" />
                <ErrorMessage name="nrOfTables" component="div" />
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
    ) : <p>Loading...</p>
}

export default EditLocal;
