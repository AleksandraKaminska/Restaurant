import React, { useState } from 'react';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import './Local.css';

const Counter: React.FC<{}> = () => {
    return (
      <div>
        <h1>Add a new local</h1>
        <Formik
          initialValues={{
            address: { street: '', apartmentNumber: '', city: '', zipCode: '' },
            nrOfTables: 1
          }}
          validate={values => {
            const errors = { address: {}} as any;
            console.log(values)
            if (!values.address.street) {
              errors.address.street = 'Required';
            }
            if (!values.address.city) {
              errors.address.city = 'Required';
            }
            if (!values.address.zipCode) {
              errors.address.zipCode = 'Required';
            }
            if (values.nrOfTables < 1)
            {
              errors.nrOfTables = 'Number of tables must be greater than 0'
            }
            return errors;
          }}
          onSubmit={(values, { setSubmitting }) => {
            setTimeout(() => {
              alert(JSON.stringify(values, null, 2));
              setSubmitting(false);
            }, 400);
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
    )
}

export default Counter;
