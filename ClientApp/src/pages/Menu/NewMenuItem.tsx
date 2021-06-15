import React, {useState} from 'react';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import { MENU_ITEMS_API_URL } from '../../constants';
import {Redirect, useParams} from "react-router-dom";

const NewMenuItem: React.FC<{}> = () => {
    const { id } = useParams()
    const [submitted, setSubmitted] = useState<boolean>(false);

    if (submitted) {
        return <Redirect to={`/locals/${id}/menu`} />
    }

    return id ? (
        <div>
            <h1>Add a new meal</h1>
            <Formik
                initialValues={{
                    title: '',
                    description: '',
                    price: 0,
                    category: ''
                }}
                onSubmit={(values, { setSubmitting }) =>
                {
                    fetch(MENU_ITEMS_API_URL, {
                        method: 'post',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify({
                            localId: id,
                            title: values.title,
                            description: values.description,
                            price: values.price,
                            category: values.category
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
                        <div className={`form-group ${errors.title && 'has-error'}`}>
                            <label htmlFor="title">Title *</label>
                            <Field type="text" name="title" className="form-control" />
                            <ErrorMessage name="title" component="div" />
                        </div>
                        <div className={`form-group ${errors.description && 'has-error'}`}>
                            <label htmlFor="description">Description *</label>
                            <Field as="textarea" name="description" className="form-control" />
                            <ErrorMessage name="description" component="div" />
                        </div>
                        <div className={`form-group ${errors.price && 'has-error'}`}>
                            <label htmlFor="price">Price *</label>
                            <Field type="number" name="price" className="form-control" />
                            <ErrorMessage name="price" component="div" />
                        </div>
                        <div className={`form-group ${errors.category && 'has-error'}`}>
                            <label htmlFor="category">Category *</label>
                            <Field type="text" name="category" className="form-control" />
                            <ErrorMessage name="category" component="div" />
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

export default NewMenuItem;
