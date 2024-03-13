
import { ChatBubbleLeftEllipsisIcon ,UserCircleIcon, CalendarDaysIcon, InboxArrowDownIcon} from "@heroicons/react/16/solid";
import React ,{ useState } from "react";
import NavlistMenu from "./nav-items";
import { MenuItem, Typography } from "@material-tailwind/react";

export default function NavMenu(){
    const [isNavOpen, setIsNavOpen] = useState(false);
    const navListItems = [
        {
            label: "Account",
            icon: UserCircleIcon,
        },
        {
            label:"Chat",
            icon:  ChatBubbleLeftEllipsisIcon
        },
        {
            label: "Calender",
            icon: CalendarDaysIcon
        },
        {
            label: "Email",
            icon: InboxArrowDownIcon
        }
    ]

    return (
        <ul className="mt-2 mb-4 flex flex-col gap-2 lg:mb-0 lg:mt-0 lg:flex-row lg:items-center">
            <NavlistMenu />
            {navListItems.map(({ label, icon }) => (
                <Typography
                    key={label}
                    as="a"
                    href="/chats"
                    variant="small"
                    color="blue-gray"
                    className="font-medium text-blue-gray-500 hover:text-blue-gray-700"
                    placeholder={label}
                >
                    <MenuItem className="flex items-center gap-2 lg:rounded-full" placeholder={label}>
                        {React.createElement (icon,{ className:"h-[18px] w-[18px] text-blue-gray-500" })}
                        <span className="text-gray-700">{label}</span>
                    </MenuItem>
                </Typography>
            ))}
        </ul>
    )
}