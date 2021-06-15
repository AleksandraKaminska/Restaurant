import React, { useEffect, useState } from 'react';
import { LOCALS_API_URL } from '../../constants';
import { FiTrash2, FiEdit2 } from 'react-icons/fi';
import { Link } from 'react-router-dom';
import {NavLink, Spinner} from "reactstrap";
import './Locals.css';

export type Local = {
    id: number
    address: {
        street: string
        apartmentNumber: string
        city: string
        zipCode: string
    }
    nrOfTables: number
}

const Locals: React.FC<{}> = () => {
    const [locals, setLocals] = useState<Array<Local>>([]);
    const [loading, setLoading] = useState<boolean>(false)

    useEffect(() => {
      fetchAllLocals().then(locals => setLocals(locals))
    }, [])
    
    const fetchAllLocals = async () => {
        setLoading(true)
        const response = await fetch(LOCALS_API_URL)
        const resp = await response.json()
        setLoading(false)
        return resp
    }

    const handleRemove = (id: number) => {
      const confirmDeletion = window.confirm('Do you really wish to delete it?');
      if (confirmDeletion) {
        fetch(`${LOCALS_API_URL}/${id}`, {
          method: 'delete',
          headers: {
            'Content-Type': 'application/json'
          }
        })
          .then(res => {
              const newLocals = locals.filter(local => local.id !== id)
              setLocals(newLocals)
          })
          .catch(err => console.log(err));
      }
    }

    return loading ? <Spinner type='primary' /> : (
      <div>
          <div className={'header'}>
              <h1>All locals</h1>
              <NavLink tag={Link} className="btn btn-primary" to="/locals/new">Add new local</NavLink>
          </div>
          <table className="table table-hover table-striped mt-5">
            <thead>
                <tr>
                  <th scope="col">#</th>
                  <th scope="col">Street</th>
                  <th scope="col">Apartment number</th>
                  <th scope="col">City</th>
                  <th scope="col">Zip code</th>
                  <th scope="col">Nr of tables</th>
                  <th scope="col" />
                </tr>
            </thead>
            <tbody>
                {locals.map((local, index) => (
                  <tr key={local.id}>
                    <th scope="row">{index + 1}</th>
                    <td>{local.address.street}</td>
                    <td>{local.address.apartmentNumber}</td>
                    <td>{local.address.city}</td>
                    <td>{local.address.zipCode}</td>
                    <td>{local.nrOfTables}</td>
                    <td>
                        <button className="btn btn-outline-danger" onClick={() => handleRemove(local.id)}>
                            <FiTrash2 />
                        </button>
                        <Link to={`/locals/${local.id}/edit`} className="btn btn-outline-primary ml-2">
                            <FiEdit2 />
                        </Link>
                        <Link to={`/locals/${local.id}/menu`} className="btn btn-outline-primary ml-2">
                            Menu
                        </Link>
                    </td>
                  </tr>
                ))}
            </tbody>
          </table>
      </div>
    )
}

export default Locals;
