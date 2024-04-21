import React, { useState ,useEffect} from 'react'
import { Button, IconButton, MobileNav, Navbar, Typography } from '@material-tailwind/react'
import NavlistMenu from './nav-items'
import { Bars2Icon } from '@heroicons/react/16/solid'
import ProfileMenu from './profile-menu'
export default function NavbarMenu() {
    const [isNavOpen, setIsNavOpen] = useState(false);
    const toggleIsNavOpen = () => setIsNavOpen((cur) => !cur);
    useEffect(() => {
        window.addEventListener(
            "resize", ()=> window.innerWidth >= 960 ? setIsNavOpen(false) : null
        )
    })
    return (
        <Navbar className="mx-auto max-w-screen-xl p-2 lg:rounded-full  lg:pl-6" placeholder={"navbar"}>
            <div className="relative mx-auto flex items-center justify-between text-blue-gray-900">
                <Typography
                    as="a"
                    href="public/dark-logo.svg"
                    className="mr-4 ml-2 cursor-pointer py-1.5 font-medium"
                    placeholder={"logo"}
                    children="ViBank"
                >
                </Typography>
                <div className="hidden lg:block">
                    <NavlistMenu />
                </div>
                <IconButton
                    size="sm"
                    color="blue-gray"
                    variant="text"
                    onClick={toggleIsNavOpen}
                    className="ml-auto mr-2 lg:hidden"
                    placeholder={"bars"}
                >
                    <Bars2Icon className="h-6 w-6" />
                </IconButton>
                <Button size="sm" variant="text" placeholder={"login"}>
                    <span>Log In</span>
                </Button>
                <ProfileMenu />
            </div>
            <MobileNav open={isNavOpen} className="overflow-scroll">
                <NavlistMenu />
            </MobileNav>
        </Navbar>
    )
}