'use client'
import React from 'react'
import RootLayout from '@/Components/Layout'
import DashboardLayout from '@/Components/DashboardLayout'
const Account = () => {
  return (
    <div>account page</div>
  )
}
Account.getLayout = (page:any)=>{
<RootLayout>
    <DashboardLayout>{page}</DashboardLayout>
</RootLayout>
}

export default Account