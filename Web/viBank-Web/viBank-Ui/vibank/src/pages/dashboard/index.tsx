'use client'
import React, { useState } from 'react'
import DashboardLayout from '@/Components/DashboardLayout'
import { Card } from 'primereact/card';
import { Button } from 'primereact/button';
import PaymentAnalytics from '@/Components/Charts/PaymentAnalytics';
import RecentActivity from '@/Components/Tables/RecentActivity';
import profile1 from '@/assets/user-01.png'
import profile2 from '@/assets/user-03.png'
import profile3 from '@/assets/user-11.png'
import profile4 from '@/assets/user-12.png'
import profile5 from '@/assets/user-06.png'
import Image from "next/image"
import InvoiceActivity from '@/Components/Tables/InvoiceActivity';
import CardSection from '@/Components/CardSection';
import Notifications from '@/Components/Notifications';
import { Dropdown } from 'primereact/dropdown';
import { InputText } from 'primereact/inputtext';
import { FaEnvelope, FaDollarSign, FaMoneyCheck } from 'react-icons/fa'
import { checkBalance } from '@/Services/transactions/transaction.service';
import { FaMoneyBillTransfer } from 'react-icons/fa6';
const Dashboard = () => {
  const [showChooseATM, setShowChooseATM] = useState(false);
  const [selectedAction, setSelectedAction] = useState('');
  const [location, setSelectedLocation] = useState('');
  const actions = [
    { name: 'Send Money', icon: FaMoneyBillTransfer },
    { name: 'Withdraw Money', icon: FaMoneyCheck }
  ]
  const locations = [
    { name: 'TorontoCA' },
    { name: 'MontrealQC' },
    { name: 'VancouverBC' },
    { name: 'CalgaryAB' },
    { name: 'OttawaOnt' },
    { name: 'Quebec' },
  ]
  const handleActionChange = (value: any) => {
    setSelectedAction(selectedAction === 'Send Money' ? 'Withdraw Money' : 'Send Money');
    setShowChooseATM(selectedAction === 'Send Money');
  };
  const handleLocationChange = (value: any) => {
    setSelectedLocation(value);
  }
  //begin sending money
  const handleProcessTransaction: any = async () => {
    //get the transaction type which has been set from the form 
    const transactionType = selectedAction;
    //TRY CATCH For each transaction type
   
    try {
      if (transactionType === 'Send Money') {
        // get the account details from local storage 
        const accountDetails = localStorage.getItem('accountDetails');
        // check the balance
        const balance = await checkBalance().then((response) => {
          
        });
      }
      if (transactionType === 'Withdraw Money') {
        //withdraw money
      }
    } catch {
      //cath respective errors

    }
  };
  return (
    <div className='grid grid-cols-3 grid-rows-3 gap-6 md:grid-cols-3 md:gap-6 xl:grid-cols-3 2xl:gap-7.5 max-sm:grid-cols-1 max-sm:gap-2 max-sm:p-2 m-auto'>
      <Card className="w-[300px] h-[200px] grid grid-cols-1 justify-items-center align-start m-auto shadow-md rounded-lg">
        <div className='grid grid-cols-1 gap-y-2'>
          <p className='text-2xl font-medium text-purple-600'>$42400.90</p>
          <p className='bg-slate-200 p-2'>January 11,2021 . <span className='bg-slate-200'>09:20 PM</span></p>
          <div className="card flex  justify-content-center m-auto">
            <Button className='bg-green-200 text-green-400 p-1 rounded-sm my-2'>%2,41</Button>
          </div>
        </div>
      </Card>
       <Card className="w-[300px] h-[200px] grid grid-cols-1 align-start m-auto p-2 shadow-md rounded-lg">
        <Dropdown
          className="flex justify-start font-bold my-2"
          value={selectedAction}
          onChange={(e) => handleActionChange(e.value)}
          options={actions}
          optionLabel="name"
          placeholder={`Selects ${selectedAction} ?`}
        />
        <div className="grid grid-cols-1 gap-y-2">
          <div className={`flex justify-content-around transition-all ${showChooseATM ? 'flip-in' : 'flip-out'}`}>
            {showChooseATM ? (
              <>
                <FaMoneyCheck className="text-violet-700 my-2" size={20} />
                <Dropdown
                  className="border-2 border-violet-700 rounded-md p-1 ml-3 w-80 "
                  placeholder=" Type ATM Locations"
                  value={location}
                  onChange={(e) => handleLocationChange(e.value)}
                  options={locations}
                  optionLabel="name"
                />
              </>
            ) : (
              <>
                <FaEnvelope className="text-violet-700 my-2" size={20} />
                <InputText className="border-2 border-violet-700 rounded-md p-1 ml-3" placeholder="barly@diapinhouse.com" />
              </>
            )}
          </div>
          <div className="flex justify-content-around">
            <FaDollarSign className="text-violet-700 my-2" size={20} />
            <InputText className="border-2 border-violet-700 rounded-md p-1 ml-3 w-80" placeholder="$1200.00" />
          </div>
          <div className="flex justify-content-center">
            <Button label="Process Transaction" className="bg-purple-900 p-1 rounded-md my-2 text-white w-full" onClick={handleProcessTransaction} />
          </div>
        </div>
      </Card>
      <div className='row-span-3'>
        <Notifications />
        <div className='ml-4 my-4 py-2'>
          <CardSection />
        </div>
        <h4 className="mb-6 px-7.5 text-xl font-bold text-black">
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

  )
}
Dashboard.getLayout = (page: any) => {
  <DashboardLayout>{page}</DashboardLayout>
}

export default Dashboard