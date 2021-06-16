import React, { useEffect, useState } from 'react';
import {Redirect, useParams} from 'react-router-dom';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import { ORDERS_API_URL} from '../../constants';
import {ListGroup, ListGroupItem, Media, Spinner} from "reactstrap";
import {fetchMenu, MenuItem} from "../Menu/Menu";
import groupBy from "lodash/groupBy";
import './Orders.css';

const EditOrder: React.FC<{}> = () => {
    let { id } = useParams<{ id: string }>();
    const [order, setOrder] = useState<any>(null);
    const [submitted, setSubmitted] = useState<boolean>(false);
    const [loading, setLoading] = useState<boolean>(false)
    const [menuItems, setMenuItems] = useState<Array<MenuItem>>([]);
    const [selectedCategory, setSelectedCategory] = useState<string>()
    const menu = groupBy(menuItems, m => m.category)
    const menuCategories = Object.keys(menu)
    
    useEffect(() => {
        const fetchOrder = async () => {
            setLoading(true)
            const response = await fetch(`${ORDERS_API_URL}/${id}`)
            const resp =  await response.json()
            setLoading(false)
            return resp
        }
        
        fetchOrder().then(order => setOrder(order))
    }, [id])

    useEffect(() => {
        if (order) {
            fetchMenu(setLoading, order.table.local.id)
                .then(menuItems => setMenuItems(menuItems))
        }
    }, [order])
    
    useEffect(() => {
        setSelectedCategory(menuCategories[0])
    }, [menuItems])
    
    console.log(order)
    
    if (submitted) {
        return <Redirect to='/orders' />
    }

    return order && !loading ? (
      <div className='d-flex justify-content-between align-items-start'>
          <div className='w-50'>
              <ListGroup horizontal className='mt-3 mb-5'>
                  {menuCategories.map(category => 
                      <ListGroupItem 
                          tag="button" 
                          color='light'
                          className='text-center' 
                          active={category === selectedCategory} 
                          action
                          key={category}
                          onClick={() => setSelectedCategory(category)}
                      >
                          {category}
                      </ListGroupItem>
                  )}
              </ListGroup>
              <ListGroup className='mt-5' flush>
                  {selectedCategory && menu[selectedCategory].map(menuItem =>
                      <ListGroupItem action type='button' key={menuItem.id}>
                          <Media>
                              <Media body>
                                  <Media heading>{menuItem.title}</Media>
                                  {menuItem.description}
                              </Media>
                              <Media right middle className='ml-2 mr-5'>
                                  <h4>{menuItem.price}</h4>
                              </Media>
                          </Media>
                      </ListGroupItem>
                  )}
              </ListGroup>
          </div>
          <div className='order-summary mt-4 ml-5 pl-5'>
              <h1 className=''>Table {order.table.id}</h1>
          </div>
      </div>
    ) : <Spinner type="primary" />
}

export default EditOrder;
