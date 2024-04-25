import React, { useState } from "react"
import { Typography, MenuItem, Menu, MenuHandler, MenuList, Card } from "@material-tailwind/react";
import logoImage from "../../assets/Logo.jpg";
import { Image } from 'primereact/image';
        
export default function NavlistMenu() {
    const navListItems = [
        {
            title: "Deposit",
            IconButton: <i className='fa-duotone fa-file-invoice-dollar' />,
            link: "/deposit",
            description: "Deposit",
        },
        {
            title: "Dashboard",
            IconButton: <i className='fa-duotone fa-chart-simple' />,
            link: "/dashboard",
            description: "Dashboard",
        },
        {
            title: "Company",
            IconButton: <i className='fa-duotone fa-cart-shopping' />,
            link: "/company",
            description: "Company",
        },
        {
            title: "Pricing",
            IconButton: <i className='fa-duotone fa-chart-simple' />,
            link: "/pricing",
            description: "Pricing",
        },
    ]
    const renderItems = navListItems.map(({ title,  link, description }) => (
        <a href={link} key={title} className="hover:bg-gray-100 p-2 rounded block text-lg font-black font-extrabold">
            {title}
        </a>
    ));
    return (
        <nav className="flex justify-around align-center mt-8">
            <ul className="flex">
                <Image src= 'dark-logo.svg' alt="logoImage" />
                <li className="m-3 font-bold">
                    <a href="/home">
                        Cardo
                    </a>
                </li>
            </ul>
            <ul className="flex ">
                {renderItems}
            </ul>
        </nav>
    )
}
