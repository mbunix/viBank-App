import React,{useState} from "react"
import {  Typography,  MenuItem, Menu, MenuHandler, MenuList, Card } from "@material-tailwind/react";
import { ChevronDownIcon, Square3Stack3DIcon } from "@heroicons/react/16/solid";
export default function NavlistMenu() {
     const [isMenuOpen, setIsMenuOpen] = useState(false);
          
    const navListItems = [
        {
            title: "Chat Application",
            IconButton: <i className='fa-duotone fa-messages' />,
            link: "/chats",
            description: "Messages & Emails",
        },
        {
            title: "Invoicing",
            IconButton: <i className='fa-duotone fa-file-invoice-dollar' />,
            link: "/invoices",
            description: "Invoices & Payments",
        },
        {
            title: "Reports",
            IconButton: <i className='fa-duotone fa-chart-simple' />,
            link: "/reports",
            description: "Reports",
        },
        {
            title: "Todos",
            IconButton: <i className='fa-duotone fa-cart-shopping' />,
            link: "/todos",
            description: "Pending Tasks",
        },
        {
            title: "Tracking",
            IconButton: <i className='fa-duotone fa-chart-simple' />,
            link: "/tracking",
            description: "Tracking & Analytics",
        },
        {
            title: 'Email Application',
            IconButton: <i className='fa-duotone fa-envelope-open' />,
            link: "/email",
            description: "Get New Emails",
        }
    ]
        const renderItems = navListItems.map(({ title, IconButton, link, description }) => (
            <a href={link} key={title}>
                <MenuItem placeholder={title}>
                    {IconButton}
                    <Typography variant="h6" color="blue-gray" className="mb-1 font-normal" children={title} placeholder={title} />
                    <Typography variant="small" color="blue-gray" className="mb-1 font-normal" children={description} placeholder={description} />
                    
                </MenuItem>
            </a>
        ));
    
        return (
            <Menu allowHover open={isMenuOpen} handler={setIsMenuOpen}>
                <MenuHandler>
                    <MenuItem className="hidden items-center gap-2 font-medium text-blue-gray-900 lg:flex lg:rounded-full" placeholder={"ChatApps"} >
                        <Square3Stack3DIcon className="h-[18px] w-[18px] text-blue-gray-500" />{""}
                        Apps{""}
                        <ChevronDownIcon strokeWidth={2} className={`h-3 w-3 transition-transform ${isMenuOpen ? 'rotate-180' : ''}`} />
                    </MenuItem>
                
                </MenuHandler>

                <MenuList className="hidden w- [40rem] grid-cols-10 gap-4 overflow-auto lg:grid-flow-col " placeholder={"QuickLinks"}>
                     <ul className="col-span-6  flex-col gap-4">
                        {renderItems}
                    </ul>
                    <Card
                        color="transparent"
                        shadow={false}
                        className="col-span-3 grid h-full w-full place-items-center rounded-md"
                        placeholder={"QuickLinks"}
                    >
                        <h4>QuickLinks</h4>
                        <li> <a href="/about">Terms and Conditions</a></li>
                        <li> <a href="/e-manager">Employee Manager</a></li>
                        <li><a href="/todos">Get Todos</a></li>
                        <li><a href="/pricing">Our Latest Prices</a></li>
                    </Card>
                </MenuList>
            </Menu>
        )
    }
