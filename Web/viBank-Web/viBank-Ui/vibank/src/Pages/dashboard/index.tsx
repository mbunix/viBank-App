'use client'
import React from 'react'
import DashboardLayout from '@/Components/DashboardLayout'
const Dashboard = () => {
  return (
    <div></div>
  )
}
Dashboard.getLayout = (page:any)=>{
    <DashboardLayout>{page}</DashboardLayout>
}

export default Dashboard