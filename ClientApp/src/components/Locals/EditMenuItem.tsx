import React, { useEffect, useState } from 'react';
import {Redirect, useParams} from 'react-router-dom';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import { MENU_ITEMS_API_URL} from '../../constants';
import {MenuItem} from "./Menu";
import './Locals.css';

const EditMenuItem: React.FC<{}> = () => {
    let { id, itemId } = useParams<{ id: string, itemId: string }>();
    const [item, setItem] = useState<MenuItem>();
    const [submitted, setSubmitted] = useState<boolean>(false);

    useEffect(() => {
      fetchMenuItem().then(item => setItem(item))
    }, [])

    const fetchMenuItem = async () => {
        const response = await fetch(`${MENU_ITEMS_API_URL}/${itemId}`)
        return await response.json()
    }
    
    if (submitted) {
        return <Redirect to={`/locals/${id}/menu`} />
    }

    return item ? (
      <div>
        <h1>Edit a menu item</h1>
        <Formik
          initialValues={{
              title: item.title,
              description: item.description,
              price: item.price,
          }}
          onSubmit={(values, { setSubmitting }) =>
          {
            fetch(`${MENU_ITEMS_API_URL}/${itemId}`, {
                method: 'put',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    title: values.title,
                    description: values.description,
                    price: values.price
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

export default EditMenuItem;
