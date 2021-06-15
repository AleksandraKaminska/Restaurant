import React, { useEffect, useState } from 'react';
import { TABLES_API_URL} from '../../constants';
import { FiEdit2 } from 'react-icons/fi';
import { Link } from 'react-router-dom';
import {NavLink, Spinner} from "reactstrap";
import './Tables.css';

enum StatusType {
    Free,
    Occupied,
    Reserved
}

type Table = {
    id: number
    localId: number
    status: StatusType
}

const Tables: React.FC<{}> = () => {
    const [tables, setTables] = useState<Array<Table>>([]);
    const [loading, setLoading] = useState<boolean>(false)

    useEffect(() => {
      fetchAllTables().then(tables => setTables(tables))
    }, [])
    
    const fetchAllTables = async () => {
        setLoading(true)
        const response = await fetch(TABLES_API_URL)
        const resp = await response.json()
        setLoading(false)
        return resp
    }

    return loading ? <Spinner type="primary"/> : (
      <div>
          <div className='header'>
              <h1>All tables</h1>
              <NavLink tag={Link} className="btn btn-primary" to="/tables/new">Add a new table</NavLink>
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
                {tables.map((table, index) => (
                  <tr key={table.id}>
                    <th scope="row">{index + 1}</th>
                    <td>{getStatusName(table.status)}</td>
                    <td>
                      <Link to={`/tables/${table.id}/edit`} className="btn btn-outline-primary ml-2">
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
    status == StatusType.Free
        ? 'Free' 
        : status == StatusType.Occupied 
            ? 'Occupied' 
            : 'Reserved';

export default Tables;
