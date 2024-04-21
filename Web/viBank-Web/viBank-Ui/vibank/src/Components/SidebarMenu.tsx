import React from 'react'
import Link from 'next/link'
import { usePathname } from 'next/navigation'
import { FaTachometerAlt } from "react-icons/fa";
import { BiSolidUserAccount } from "react-icons/bi";
import { MdOutlineSettings } from "react-icons/md";
import { FaIndustry } from "react-icons/fa";
import { IoIosPricetags } from "react-icons/io";

const ActiveMenuLink = ({children,href}:any)=>{
    const pathName = usePathname();
    const active = href === pathName;
    console.log(pathName,active)
    return (
        <Link
          href={href}
          className={`hover:bg-gray-100 p-2 rounded block text-sm ${
            active ? 'text-purple-400 font-semibold' : 'text-gray-500'
          }`}
        >
          {children}
        </Link>
      );
}



const SidebarMenu = () => {
  return (
    <nav className="h-[100vh] w-[100%]">
    <ul className="flex flex-col justify-between h-[100%]">
        <div className='h-[25%] justify-center m-auto'>
        <li className='w-full'>
        <ActiveMenuLink href="/dashboard" >
        <FaTachometerAlt className="text-2xl"/>
        </ActiveMenuLink>
      </li>
        </div>
        <div className='grid grid-cols-1 justify-items-center m-auto  h-[50%]'>
        <li className='w-full'>
        <ActiveMenuLink href="/dashboard/account">
        <BiSolidUserAccount  className="text-2xl"/>
        </ActiveMenuLink>
      </li>
      <li className='w-full'>
        <ActiveMenuLink href="/dashboard/company">
        <FaIndustry className="text-2xl"/>
        </ActiveMenuLink>
      </li>
      <li className='w-full'>
        <ActiveMenuLink href="/dashboard/pricing">
        <IoIosPricetags  className="text-2xl"/>
        </ActiveMenuLink>
      </li>
        </div>
        <div className='flex justify-center align-center m-auto h-[25%]'>
        <li className='self-end w-full'>
        <ActiveMenuLink href="/dashboard/settings">
        <MdOutlineSettings className="text-2xl"/>
        </ActiveMenuLink>
      </li>
        </div>
    </ul>
  </nav>
  )
}

export default SidebarMenu