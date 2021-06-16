import React, { useEffect, useState } from 'react';
import { ORDERS_API_URL } from '../../constants';
import { FiEdit2 } from 'react-icons/fi';
import { Link } from 'react-router-dom';
import { DropdownItem, DropdownMenu, DropdownToggle, NavLink, Spinner, UncontrolledDropdown} from "reactstrap";
import {Table} from "../Tables/Tables";
import './Orders.css';

enum StatusType {
    Received,
    InPreparation,
    Done
}

export type Order = {
    id: number
    status: StatusType
    table: Table
}

const Orders: React.FC<{}> = () => {
    const [orders, setOrders] = useState<Array<Order>>([]);
    const [loading, setLoading] = useState<boolean>(false)
    
    useEffect(() => {
      fetchAllOrders().then(orders => setOrders(orders))
    }, [])
    
    const fetchAllOrders = async () => {
        setLoading(true)
        const response = await fetch(ORDERS_API_URL)
        const resp = await response.json()
        setLoading(false)
        return resp
    }

    const changeOrderStatus = (id: number, status: StatusType) => {
        fetch(`${ORDERS_API_URL}/${id}`, {
            method: 'put',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ status })
        })
            .then(res => {
                const newOrders: Array<Order> = orders.map(order => {
                    if (order.id === id) {
                        order.status = status
                    }
                    return order
                })
                setOrders(newOrders)
                return res.json()
            })
            .catch(err => console.log(err));
    }

    return loading ? <Spinner type="primary"/> : (
      <div>
          <div className={'header'}>
              <h1>All orders</h1>
              <NavLink tag={Link} className="btn btn-primary" to="/orders/new">Add a new order</NavLink>
          </div>
          <table className="table table-hover table-striped mt-5">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Status</th>
                    <th scope="col">Table nr</th>
                    <th scope="col" />
                </tr>
            </thead>
            <tbody>
                {orders.map((order, index) => (
                  <tr key={order.id}>
                      <th scope="row">{order.id}</th>
                      <td>
                          <UncontrolledDropdown>
                              <DropdownToggle caret color={'light'}>
                                  {getStatusName(order.status)}
                              </DropdownToggle>
                              <DropdownMenu>
                                  <DropdownItem onClick={() => changeOrderStatus(order.id, StatusType.Received)}>{getStatusName(StatusType.Received)}</DropdownItem>
                                  <DropdownItem onClick={() => changeOrderStatus(order.id, StatusType.InPreparation)}>{getStatusName(StatusType.InPreparation)}</DropdownItem>
                              </DropdownMenu>
                          </UncontrolledDropdown>
                      </td>
                      <td>{order.table.id}</td>
                      <td>
                        <Link to={`/orders/${order.id}/edit`} className="btn btn-outline-primary ml-2">
                            <FiEdit2 />
                        </Link>
                      </td>
                  </tr>
                ))}
            </tbody>
          </table>
      </div>
    )
}

const getStatusName = (status: StatusType) => 
    status === StatusType.Received 
        ? 'Received' 
        : status === StatusType.InPreparation 
            ? 'In Preparation' 
            : 'Done';

export default Orders;
