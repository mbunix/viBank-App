import { ChevronDownIcon, RectangleStackIcon } from "@heroicons/react/16/solid";
import {  UserIcon, InboxIcon, PowerIcon } from "@heroicons/react/24/solid";
import { Avatar, Button, Menu, MenuHandler, MenuItem, MenuList, Typography } from "@material-tailwind/react";
import React, { useState } from "react";

export default function profileMenu() {
  const [isMenuOpen, setIsMenuOpen] = useState(false);
  const closeMenu = () => setIsMenuOpen(false);
  const profileMenuItems = [
    {
      label: "My Profile",
      icon: UserIcon,
      description: "Account Settings"
    },
    {
      label: "Inbox",
      icon: InboxIcon,
      description: "Messages & Emails"
    },
    {
      label: "My Tasks",
      icon: RectangleStackIcon,
      description: "Pending Tasks"
    },
    {
      label: "Sign Out",
      icon: PowerIcon,
      description: "Logout"
    },
  ];


  return (
    <Menu open={isMenuOpen} handler={setIsMenuOpen} placement="bottom-end">
      <MenuHandler>
        <Button
          variant="text"
          color="blue-gray"
          className="flex items-center  gap-1 rounded-full py-0.5 pr-0.5 pl-0.5 lg:ml-auto"
          placeholder={"user"}
        >
          <Avatar
            variant="circular"
            size="sm"
            alt="{username}"
            placeholder={"profile-pic"}
          />
          <ChevronDownIcon
            strokeWidth={2.5}
            className={` h-3 w-3 transition-transform ${isMenuOpen ? "rotate-180" : ""
              }`}
          />
        </Button>
      </MenuHandler>
      <MenuList className="p-1" placeholder={"menuitems"}>
        {profileMenuItems.map(({ label, icon, description }, key) => {
          const isLastItem = key === profileMenuItems.length - 1;
          return (
            <MenuItem 
              key={label}
              onClick={closeMenu}
              className={`flex items-center gap-2 rounded ${
                isLastItem ?
                 "hover:bg-blue-500 hover:text-white" : "hover:bg-red-300 hover:text-white"
                }`}
              placeholder={label}
            >
              {React.createElement(icon, {
                className: `h-4 w-4 ${isLastItem ? "text-white" : "text-blue-500"}`,
                strokeWidth: 2,
              })}
               <Typography
                as="span"
                variant="small"
                className="font-normal"
                color={isLastItem ? "red" : "inherit"}
                placeholder={description}
              >
                {label}
              </Typography>
            </MenuItem>
          )
        })}
        </MenuList>
    </Menu>
  )
}