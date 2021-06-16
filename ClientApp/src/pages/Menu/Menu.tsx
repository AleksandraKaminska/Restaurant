import React, { useEffect, useState } from 'react';
import {ListGroup, ListGroupItem, ListGroupItemHeading, Media, NavLink, Spinner} from 'reactstrap';
import List from "reactstrap/lib/List";
import {LOCALS_API_URL, MENU_ITEMS_API_URL} from '../../constants';
import { FiTrash2, FiEdit2 } from 'react-icons/fi';
import {Link, useParams} from 'react-router-dom';
import groupBy from "lodash/groupBy";

export type MenuItem = {
    id: number
    title: string
    description: string
    price: number
    category: string
}

const Menu: React.FC<{}> = () => {
    const [menuItems, setMenuItems] = useState<Array<MenuItem>>([]);
    const [loading, setLoading] = useState<boolean>(false)
    const { id } = useParams()

    useEffect(() => {
        fetchMenu(setLoading, id)
            .then(menuItems => setMenuItems(menuItems))
    }, [id])

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
                    const newMenuItems = menuItems.filter(item => item.id !== id)
                    setMenuItems(newMenuItems)
                })
                .catch(err => console.log(err));
        }
    }
    
    const menu = groupBy(menuItems, m => m.category)
    const menuCategories = Object.keys(menu)
    
    return loading ? <Spinner color="primary" /> : (
        <div>
            <div className={'header'}>
                <h1>Menu</h1>
                <NavLink tag={Link} className="btn btn-primary" to={`/locals/${id}/menu/items/new`}>Add new item</NavLink>
            </div>

            <ListGroup className='mt-5'>
                {menuCategories.map(category => 
                    <ListGroupItem key={category}>
                        <ListGroupItemHeading>{category}</ListGroupItemHeading>
                        <List type="unstyled" className='mt-5'>
                            {
                                menu[category].map((menuItem: MenuItem) => (
                                    <li key={menuItem.id}>
                                        <Media className="mt-4">
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
                    </ListGroupItem>
                )}
            </ListGroup>
        </div>
    )
}

export const fetchMenu = async (callback: React.Dispatch<React.SetStateAction<boolean>>, id: number) => {
    callback(true)
    const response = await fetch(`${LOCALS_API_URL}/${id}/menu`)
    const resp = await response.json()
    callback(false)
    return resp
}

export default Menu;
