import React from 'react'
import SidebarMenu from './SidebarMenu'

const DashboardLayout = ({ children }: any) => {
  return (
    <div className='flex'>
      <aside className='flex-[1]'>
        <SidebarMenu />
      </aside>
      <div className="bg-gray-100 flex-[11] p-4 rounded min-h-[300px">
        {children}
      </div>
    </div>
  )
}

export default DashboardLayout