import React from 'react'
import { FaBasketShopping } from "react-icons/fa6";
import { BsFillSendFill } from "react-icons/bs";
import { FaRegCreditCard } from "react-icons/fa";
import { AiOutlineThunderbolt } from "react-icons/ai";

const chatData: any = [
    {
      avatar: <FaBasketShopping />,
      name:  "Shopping",
      amount: "- $800.00",
      date:"04 Jan 2021,09:20 AM"
    },
    {
      avatar: <BsFillSendFill  />,
      name: 'Sent to James',
      amount: "+ $500.00",
      date:"03 Jan 2021,10:40 AM"
    },
    {
      avatar: <FaRegCreditCard  />,
      name: 'Paypal Received',
      amount: "+ $500.00",
      date:"02 Jan 2021,10:40 AM"
    },
    {
      avatar: <AiOutlineThunderbolt />,
      name: 'Topup Game',
      amount: "- $240.00",
      date:"01 Jan 2021,10:40 AM"
    }
  ];

const RecentActivity = () => {
  return (
    <div className="col-span-12 rounded-sm border border-stroke bg-white py-6 shadow-default dark:border-strokedark dark:bg-boxdark xl:col-span-4">
    <h4 className="mb-6 px-7.5 text-xl font-bold text-black dark:text-white">
      Recent Activity
    </h4>

    <div className='px-2'>
      {chatData?.map((chat:any,i:number) => (
    <div key={i} className='flex justify-between align-center my-4'>
          <div className="relative h-14 w-14 rounded-full">
            {chat.avatar}
            <span
              className="absolute right-0 bottom-0 h-3.5 w-3.5 rounded-full border-2 border-white"
              style={{backgroundColor: chat.color}}
            ></span>
          </div>
          <div className="flex flex-col  items-center justify-between">      
              <h5 className="font-medium text-black dark:text-white">
                {chat.name}
              </h5>
              <p>
                <span className="text-xs">{chat.date}</span>
              </p>  
          </div>
            <div>
            <span className="text-sm text-black dark:text-white">
                  {chat.amount}
                </span> 
            </div>
    </div>      
      ))}
    </div>
  </div>
  )
}

export default RecentActivity