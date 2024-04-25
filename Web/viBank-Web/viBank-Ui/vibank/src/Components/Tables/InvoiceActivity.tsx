import React from 'react'
import { DataGrid } from '@mui/x-data-grid'
import { invoiceData } from '@/Dummy/Data'
import Image from "next/image";

const InvoiceActivity = () => {
    interface RenderCellParams {
        row: {
            id: number;
            image: string;
            profile: string;
        }
    }
    const columns = [
        {
            field: "invoiceNo",
            headerName: "Invoice Number",
            width: 150
        },
        {
            field: "recipient",
            headerName: "Recipient",
            width: 150
        },
        {
            field: "profile",
            headerName: "Profile",
            width: 150,
            renderCell: (params: RenderCellParams) => {
                return (
                    <div className="profileImage">
                        <Image className="profileImage rounded-md" src={params.row.profile} alt="Profile Image" width={50} height={50} />
                    </div>
                );
            },
        },
        {
            field: "status",
            headerName: "Status",
            width: 150
        },
        {
            field: "action",
            headerName: "Action",
            width: 150
        },
        {
            field: "amount",
            headerName: "Amount",
            width: 150
        }
    ]
    return (
        <div className="rounded-sm border border-stroke bg-white px-5 pt-6 pb-2.5 shadow-default dark:border-strokedark dark:bg-boxdark sm:px-7.5 xl:pb-1">
            <p className='text-start font-semibold'>Requested services</p>
            <div style={{ width: '100%', overflowX: 'scroll' }}>
                <DataGrid
                    rows={invoiceData}
                    columns= {columns}
                    getRowId={(row: any) => row?.id}
                    checkboxSelection
                    sx={{
                        m: 2,
                        borderColor: 'primary.light',
                        '& .MuiDataGrid-cell:hover': {
                            color: 'primary.main',
                            maxHeight: "100%"
                        },
                    }}
                />
            </div>
        </div>
    )
}

export default InvoiceActivity