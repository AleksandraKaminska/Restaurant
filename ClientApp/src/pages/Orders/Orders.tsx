import React, { useEffect, useState } from 'react';
import { ORDERS_API_URL } from '../../constants';
import { FiEdit2 } from 'react-icons/fi';
import { Link } from 'react-router-dom';
import {NavLink, Spinner} from "reactstrap";
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
                      <th scope="row">{index + 1}</th>
                      <td>{getStatusName(order.status)}</td>
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
            ? 'InPreparation' 
            : 'Done';

export default Orders;
