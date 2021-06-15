import React, { useEffect, useState } from 'react';
import { ORDERS_API_URL } from '../../constants';
import { FiEdit2 } from 'react-icons/fi';
import { Link } from 'react-router-dom';
import {NavLink, Spinner} from "reactstrap";
import './Orders.css';

type Order = {
    id: number
    status: 'received' | 'in preperation' | 'done'
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
                  <th scope="col" />
                </tr>
            </thead>
            <tbody>
                {orders.map((order, index) => (
                  <tr key={order.id}>
                    <th scope="row">{index + 1}</th>
                    <td>{order.status}</td>
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

export default Orders;
