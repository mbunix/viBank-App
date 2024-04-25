'use client'
import React, { useState } from 'react'
import DashboardLayout from '@/Components/DashboardLayout'
import { Card } from 'primereact/card';
import { InputText } from 'primereact/inputtext';
import { MdOutlineEmail } from "react-icons/md";
import { Button } from 'primereact/button';
import { SiCashapp } from "react-icons/si";
import PaymentAnalytics from '@/Components/Charts/PaymentAnalytics';
import RecentActivity from '@/Components/Tables/RecentActivity';
import profile1 from '@/assets/user-01.png'
import profile2 from '@/assets/user-03.png'
import profile3 from '@/assets/user-11.png'
import profile4 from '@/assets/user-12.png'
import profile5 from '@/assets/user-06.png'
import Image from "next/image"
import { invoiceData } from '@/Dummy/Data';
import InvoiceActivity from '@/Components/Tables/InvoiceActivity';
import CardSection from '@/Components/CardSection';
import Notifications from '@/Components/Notifications';

const Dashboard = () => {
  const [value, setValue] = useState('');
  const [cashValue, setCashValue] = useState('');
  return (
    <>
      <div className='grid grid-cols-3 grid-rows-3 gap-6 md:grid-cols-3 md:gap-6 xl:grid-cols-3 2xl:gap-7.5 max-sm:grid-cols-1 max-sm:gap-2 max-sm:p-2 m-auto'>
        <Card className="w-[400px] h-[200px] grid grid-cols-1 justify-items-center align-start m-auto shadow-md rounded-md">
          <div className='flex justify-around align-center m-auto'>
          </div>
          <p className='font-bold my-4'>Your Total Balance</p>
          <div className='grid grid-cols-1 gap-y-4'>
            <p className='text-2xl font-medium text-purple-600'>$42400.90</p>
            <p className='bg-slate-200 p-2'>January 11,2021 . <span className='bg-slate-200'>09:20 PM</span></p>
            <div className="card flex  justify-content-center m-auto">
              <Button className='bg-green-200 text-green-400 p-1 rounded-sm my-2'>%2,41</Button>
            </div>
          </div>
        </Card>
        <Card className='w-[400px] h-[200px] grid grid-cols-1 justify-items-center align-start m-auto shadow-md rounded-md'>
          <p className='flex justify-start font-bold'>Send Money</p>
          <div className="card grid grid-cols-1 gap-y-6 justify-items-start ">
            <InputText className='border-purple-400 border-2 rounded-md w-full' />
            <InputText className='border-purple-400 border-2 rounded-md w-full' />
            <div className="card flex justify-content-center m-auto">
              <Button label="Submit" className='bg-purple-600 p-1 rounded-md' />
            </div>
          </div>
        </Card>
        <div className='row-span-3'>
          <Notifications />
          <div className='my-4 py-2'>
            <CardSection />
          </div>
          <h4 className="mb-6 px-7.5 text-xl font-bold text-black dark:text-white">
            Send Again
          </h4>
          <div className='rounded-sm bg-white py-2 shadow-default my-3'>
            <div className="flex justify-between align-center m-auto profiles px-3">
              <Image src={profile1} alt="Profile One" height={100} width={50} />
              <Image src={profile2} alt="Profile Two" height={100} width={50} />
              <Image src={profile3} alt="Profile Three" height={100} width={50} />
              <Image src={profile4} alt="Profile Four" height={100} width={50} />
              <Image src={profile5} alt="Profile Five" height={100} width={50} />
            </div>
          </div>
          <RecentActivity />
        </div>
        <div className='col-span-2'>
          <PaymentAnalytics />
        </div>
        <div className='col-span-2'>
          <InvoiceActivity />
        </div>
      </div>
    </>
  )
}
Dashboard.getLayout = (page: any) => {
  <DashboardLayout>{page}</DashboardLayout>
}

export default Dashboard