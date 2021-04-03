import React, { useEffect, useState } from 'react';
import { LOCALS_API_URL } from '../../constants';
import './Local.css';

const List: React.FC<{}> = () => {
    const [locals, setLocals] = useState<Array<any>>([]);

    useEffect(() => {
      fetchAllLocals()
        .then(locals => setLocals(locals))
    }, [])

    const fetchAllLocals = async () => {
      const response = await fetch(LOCALS_API_URL)
      const json = await response.json()
      return json
    }

    return (
      <div>
        <h1>All locals</h1>
        <table className="table table-hover table-striped mt-5">
          <thead>
            <tr>
              <th scope="col">#</th>
              <th scope="col">Street</th>
              <th scope="col">Apartment number</th>
              <th scope="col">City</th>
              <th scope="col">Zip code</th>
              <th scope="col">Nr of tables</th>
            </tr>
          </thead>
          <tbody>
            {locals.map((local, index) => (
              <tr key={index + 1}>
                <th scope="row">{index + 1}</th>
                <td>{local.address.street}</td>
                <td>{local.address.apartmentNumber}</td>
                <td>{local.address.city}</td>
                <td>{local.address.zipCode}</td>
                <td>{local.nrOfTables}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    )
}

export default List;
