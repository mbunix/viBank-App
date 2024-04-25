import React from 'react'
import CreditCard from "../assets/Credit_Card.jpg"
import { BsThreeDots } from "react-icons/bs";
import Image from "next/image";
const CardSection = () => {
  return (
    <div className='shadow-lg flex flex-col'>
      <div className='flex justify-between align-center'>
        <p className='font-bold text-lg'>Your Card</p>
        <BsThreeDots />
      </div>
      <div className='p-2'>
        <Image src={CreditCard} alt='Credit Card' className='w-[80%] flex justify-center align-center m-auto' />
      </div>
    </div>
  )
}

export default CardSection