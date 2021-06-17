import React, { useEffect, useState } from 'react';
import { useParams} from 'react-router-dom';
import {ORDER_MENU_ITEMS_API_URL, ORDERS_API_URL} from '../../constants';
import {ListGroup, ListGroupItem, Media, Spinner} from "reactstrap";
import {fetchMenu, MenuItem} from "../Menu/Menu";
import groupBy from "lodash/groupBy";
import OrderSummary, {OrderMenuItem} from "./OrderSummary";
import './Orders.css';

const EditOrder: React.FC<{}> = () => {
    let { id } = useParams<{ id: string }>();
    const [order, setOrder] = useState<any>(null);
    const [loading, setLoading] = useState<boolean>(false)
    const [menuItems, setMenuItems] = useState<Array<MenuItem>>([]);
    const [selectedCategory, setSelectedCategory] = useState<string>()
    const [orderMenuItems, setOrderMenuItems] = useState<Array<OrderMenuItem>>([])
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
        
        fetchOrder().then(order => {
            setOrder(order)
            setOrderMenuItems(order.orderMenuItems)
        })
    }, [id])
    
    useEffect(() => {
        if (order) {
            fetchMenu(setLoading, order.table.localId)
                .then(menuItems => setMenuItems(menuItems))
        }
    }, [order])
    
    useEffect(() => {
        setSelectedCategory(menuCategories[0])
    }, [menuItems])
    
    const addItemToOrder = (menuItemId: number) => {
        const orderMenuItem = orderMenuItems.find(o => o.menuItem.id === menuItemId)
            orderMenuItem ? fetch(`${ORDER_MENU_ITEMS_API_URL}/${orderMenuItem.id}`, {
                    method: 'put',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({
                        quantity: orderMenuItem.quantity + 1
                    })
                })
                    .then(res => {
                        setOrderMenuItems(orderMenuItems.map(el => {
                            if (el.menuItem.id === menuItemId) {
                                el.quantity += 1
                            }
                            return el
                        }))
                        return res.json()
                    })
                    .catch(err => console.log(err)) :
        fetch(ORDER_MENU_ITEMS_API_URL, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                orderId: id,
                menuItemId: menuItemId,
                quantity: 1
            })
        })
            .then(res => res.json())
            .then(data => setOrderMenuItems([...orderMenuItems, data]))
            .catch(err => console.log(err))
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
                      <ListGroupItem action type='button' onClick={() => addItemToOrder(menuItem.id)} key={menuItem.id}>
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
          <OrderSummary order={order} orderMenuItems={orderMenuItems} setOrderMenuItems={setOrderMenuItems} />
      </div>
    ) : <Spinner type="primary" />
}

export default EditOrder;
