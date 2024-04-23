import React from 'react'
import { FaBell } from "react-icons/fa";
import notificationProfile from "../assets/user-06.png";
import Image from "next/image";

const Notifications = () => {
  return (
<div className='flex justify-between align-center m-auto '>
<FaBell className='text-purple-400 text-3xl cursor-pointer shadow-md rounded-md'/>
<Image  src={notificationProfile} alt='Profile_Image' className='rounded-md cursor-pointer' width={50} height={50}  />
</div>
  )
}

export default Notifications