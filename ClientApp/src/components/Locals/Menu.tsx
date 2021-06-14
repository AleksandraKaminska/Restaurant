import React, { useEffect, useState } from 'react';
import { Media, NavLink } from 'reactstrap';
import List from "reactstrap/lib/List";
import {LOCALS_API_URL, MENU_ITEMS_API_URL} from '../../constants';
import { FiTrash2, FiEdit2 } from 'react-icons/fi';
import {Link, useParams} from 'react-router-dom';
import './Locals.css';

export type MenuItem = {
    id: number
    title: string
    description: string
    price: number
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
        setLoading(false)
        return resp
    }

    const handleRemove = (id: number) => {
        const confirmDeletion = window.confirm('Do you really wish to delete it?');
        if (confirmDeletion) {
            fetch(`${MENU_ITEMS_API_URL}/${id}`, {
                method: 'delete',
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(res => {
                    const newMenu = menu.filter(item => item.id !== id)
                    setMenu(newMenu)
                })
                .catch(err => console.log(err));
        }
    }


    return loading ? <p>Loading...</p> : (
        <div>
            <div className={'header'}>
                <h1>Menu</h1>
                <NavLink tag={Link} className="btn btn-primary" to={`/locals/${id}/menu/items/new`}>Add new item</NavLink>
            </div>
            <List type="unstyled" className='mt-5'>
                {
                    menu.map(menuItem => (
                        <li key={menuItem.id}>
                            <Media className="mt-1">
                                <Media body>
                                    <Media heading>{menuItem.title}</Media>
                                    {menuItem.description}
                                </Media>
                                <Media right middle className='ml-2 mr-5'>
                                    <h4>{menuItem.price}</h4>
                                </Media>
                                <Media right middle className='ml-2'>
                                    <button className="btn btn-outline-danger" onClick={() => handleRemove(menuItem.id)}>
                                        <FiTrash2 />
                                    </button>
                                    <Link to={`/locals/${id}/menu/items/${menuItem.id}/edit`} className="btn btn-outline-primary ml-2">
                                        <FiEdit2 />
                                    </Link>
                                </Media>
                            </Media>
                        </li>
                    ))
                }
            </List>
        </div>
    )
}

export default Menu;
