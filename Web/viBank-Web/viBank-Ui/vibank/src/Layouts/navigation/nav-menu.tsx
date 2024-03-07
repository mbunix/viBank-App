import { BriefcaseIcon } from "@heroicons/react/16/solid";
import { UserCircleIcon } from "@heroicons/react/16/solid";
import React ,{ useState } from "react";

export default function NavMenu(){
    const [isNavOpen, setIsNavOpen] = useState(false);
    const navListItems = [
        {
            label: "Account",
            icon: UserCircleIcon,
        },
        {
            label:"Activities",
            icon:  BriefcaseIcon
        },
        {
        }
    ]
}