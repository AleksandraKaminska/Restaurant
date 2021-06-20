import React from 'react';
import {useLocation, Link} from "react-router-dom";
import {Button, ListGroup, ListGroupItem} from "reactstrap";
import {Order} from "./Orders";
import {MenuItem} from "../Menu/Menu";
import {ORDER_MENU_ITEMS_API_URL} from "../../constants";
import './Orders.css';

export type OrderMenuItem = {
    quantity: number
    id: number
    menuItem: MenuItem
}

type OrderSummaryProps = {
    order: Omit<Order, 'orderMenuItems'>
    orderMenuItems: Array<OrderMenuItem>
    setOrderMenuItems: React.Dispatch<React.SetStateAction<OrderMenuItem[]>>
    editable?: boolean
}

const OrderSummary: React.FC<OrderSummaryProps> = ({ order, orderMenuItems, setOrderMenuItems, editable = true }) => {
    const {pathname} = useLocation()
    const orderTotal = orderMenuItems.reduce((prev, { quantity, menuItem}) =>
            prev + menuItem.price * quantity, 0)
    
    const editItemQuantity = (id: number, newQuantity: number) => {
        fetch(`${ORDER_MENU_ITEMS_API_URL}/${id}`, {
            method: 'put',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                quantity: newQuantity
            })
        })
            .then(res => {
                return res.json()
            })
            .catch(err => console.log(err));
    }

    const removeItem = (id: number) => {
        fetch(`${ORDER_MENU_ITEMS_API_URL}/${id}`, {
            method: 'delete',
            headers: {
                'Content-Type': 'application/json'
            },
        })
            .then(res => {
                setOrderMenuItems(orderMenuItems.filter(el => el.id !== id))
                return res.json()
            })
            .catch(err => console.log(err));
    }
    
    const handleMinusClick = (quantity: number, id: number) => {
        if (quantity == 1) {
            removeItem(id)
        } else {
            setOrderMenuItems(orderMenuItems.map(el => {
                if (el.id === id) { 
                    el.quantity -= 1
                }
                return el
            }))
            editItemQuantity(id, quantity - 1)
        }
    }

    const handlePlusClick = (quantity: number, id: number) => {
        setOrderMenuItems(orderMenuItems.map(el => {
            if (el.id === id) {
                el.quantity += 1
            }
            return el
        }))
        editItemQuantity(id, quantity + 1)
    }
    
    return (
        <div className='order-summary mt-4 ml-5 pl-4 d-flex flex-column justify-content-between'>
            <div className='sticky-top bg-white'>
                <h1>Table {order.table.id}</h1>
            </div>
            <ListGroup flush className='w-100 mb-4 mt-5 mb-5 items'>
                {orderMenuItems.map(orderMenuItem => 
                    <ListGroupItem key={orderMenuItem.id} className='d-flex justify-content-between align-items-center'>
                        <span>{orderMenuItem.menuItem?.title}</span>
                        <div>
                            {editable && <Button 
                                outline 
                                className='pt-0 pb-0'
                                color="secondary" 
                                onClick={() => handleMinusClick(orderMenuItem.quantity, orderMenuItem.id)}
                            >
                                -
                            </Button> }
                            <span className="text-muted mx-3 small">{orderMenuItem.quantity}</span>
                            {editable && <Button 
                                outline
                                className='pt-0 pb-0'
                                color="secondary" 
                                onClick={() => handlePlusClick(orderMenuItem.quantity, orderMenuItem.id)}
                            >
                                +
                            </Button> }
                            <span className='text-muted d-inline-block text-right ml-3 item-price small'>{orderMenuItem.menuItem.price * orderMenuItem.quantity} zł</span>
                        </div>
                    </ListGroupItem>
                )}
            </ListGroup>
            <div className='bg-white border-top pt-3 sticky-bottom d-flex flex-column justify-content-center align-items-center'>
                <ListGroup flush className='w-100 mb-4 mx-4'>
                    <ListGroupItem className='d-flex justify-content-between align-items-center'>
                        <span>Total</span>
                        <span className="text-muted">{orderTotal} zł</span>
                    </ListGroupItem>
                    <ListGroupItem className='d-flex justify-content-between align-items-center'>
                        <span>Tax</span>
                        <span className="text-muted">{orderTotal * 23 / 100} zł</span>
                    </ListGroupItem>
                </ListGroup>
                { editable && <Link to={pathname + '/payment'} className='mx-4'>
                    <Button color='primary' className='w-100' size='lg'>Proceed to payment</Button>
                </Link> }
            </div>
        </div>
    )
}

export default OrderSummary;
