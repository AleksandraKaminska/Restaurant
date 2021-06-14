import React, { useEffect, useState } from 'react';
import { LOCALS_API_URL } from '../../constants';
import { FiTrash2, FiEdit2 } from 'react-icons/fi';
import {Link, useParams} from 'react-router-dom';
import {NavLink} from "reactstrap";
import './Locals.css';

type MenuItem = {
}

const Menu: React.FC<{}> = () => {
    const [menu, setMenu] = useState<Array<MenuItem>>([]);
    const [loading, setLoading] = useState<boolean>(false)
    const { id } = useParams()

    useEffect(() => {
        fetchMenu().then(menu => setMenu(menu))
    }, [])

    const fetchMenu = async () => {
        setLoading(true)
        const response = await fetch(`${LOCALS_API_URL}/${id}/menu`)
        const resp = await response.json()
        console.log(resp)
        setLoading(false)
        return resp
    }
    
    return loading ? <p>Loading...</p> : (
        <div>
            <div className={'header'}>
                <h1>Menu</h1>
                <NavLink tag={Link} className="btn btn-primary" to={`/locals/${id}/menu/new-item`}>Add new item</NavLink>
            </div>
        {/*    <table className="table table-hover table-striped mt-5">*/}
        {/*        <thead>*/}
        {/*        <tr>*/}
        {/*            <th scope="col">#</th>*/}
        {/*            <th scope="col">Street</th>*/}
        {/*            <th scope="col">Apartment number</th>*/}
        {/*            <th scope="col">City</th>*/}
        {/*            <th scope="col">Zip code</th>*/}
        {/*            <th scope="col">Nr of tables</th>*/}
        {/*            <th scope="col" />*/}
        {/*        </tr>*/}
        {/*        </thead>*/}
        {/*        <tbody>*/}
        {/*        {locals.map((local, index) => (*/}
        {/*            <tr key={local.id}>*/}
        {/*                <th scope="row">{index + 1}</th>*/}
        {/*                <td>{local.address.street}</td>*/}
        {/*                <td>{local.address.apartmentNumber}</td>*/}
        {/*                <td>{local.address.city}</td>*/}
        {/*                <td>{local.address.zipCode}</td>*/}
        {/*                <td>{local.nrOfTables}</td>*/}
        {/*                <td>*/}
        {/*                    <button className="btn btn-outline-danger" onClick={() => handleRemove(local.id)}>*/}
        {/*                        <FiTrash2 />*/}
        {/*                    </button>*/}
        {/*                    <Link to={`/locals/${local.id}/edit`} className="btn btn-outline-primary ml-2">*/}
        {/*                        <FiEdit2 />*/}
        {/*                    </Link>*/}
        {/*                    <Link to={`/locals/${local.id}/menu`} className="btn btn-outline-primary ml-2">*/}
        {/*                        Menu*/}
        {/*                    </Link>*/}
        {/*                </td>*/}
        {/*            </tr>*/}
        {/*        ))}*/}
        {/*        </tbody>*/}
        {/*    </table>*/}
        </div>
    )
}

export default Menu;
