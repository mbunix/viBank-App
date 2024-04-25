'use client'
import React from 'react'
import RootLayout from '@/Components/Layout'
import DashboardLayout from '@/Components/DashboardLayout'
const Company = () => {
  return (
    <div>company page</div>
  )
}
Company.getLayout = (page:any)=>{
    <RootLayout>
    <DashboardLayout>{page}</DashboardLayout>
</RootLayout>
}

export default Company