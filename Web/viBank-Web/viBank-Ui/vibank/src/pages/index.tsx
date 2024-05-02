import React, { useState } from "react";
import { HiOutlineArrowLongRight } from "react-icons/hi2";
import { MdOutlineKeyboardArrowRight } from "react-icons/md";
import Image from "next/image"
import { Card } from 'primereact/card';
import stars from "../assets/starsPic.png";
import hand from "../assets/handPic.png";
import creditCard from "../assets/Credit_card.png";
import NavlistMenu from "@/Layouts/navigation/nav-items";
import RootLayout from "@/Components/Layout";
import LoginPage from "./auth/loginpage";
import { Button } from "@material-tailwind/react";
import SignUpPage from "./auth/signup-page";


const Home = () => {
   const [isSigUpWindowOpen, setIsSigUpWindowOpen] = useState(false);
   const [isLoginWindowOpen, setIsLoginWindowOpen] = useState(false);
   return (
      <><div className="w-[50%]">
         <NavlistMenu />
         
      </div>
         <div>
            <section className="mt-[5%] flex justify-around align-center m-auto h-[100vh]">
               <div className="flex-1 flex-col">
                  <article className="flex-row justify-center align-center ml-[25%]">
                     <p className="text-4xl text-center text-black  w-12 h-3.5 top-8  rotate-180 my-4">***</p>
                     <h3 className="font-normal text-4xl leading-10 tracking-wide ">All the <span className="font-bold">experience </span>  <br />in the new credit card</h3>

                     <HiOutlineArrowLongRight style={{ width: "60px", height: "91.65px", top: "451px", left: "123px", rotate: "90" }} />
                     <p className="mb-4">
                        Simple transfers, payments for utilities, functional statemement,  card settings, for which you used to have to go too the brach oonline-banking
                     </p>
                     <div className="flex rounded-lg bg-slate-200 w-3/4 justify-start align-center mt-8">
                        <button className="mr-4  p-2 bg-[#11253E] text-white">
                           Order a Card
                        </button>
                        <button className="flex justify-center align-center m-auto">
                           How it Works <MdOutlineKeyboardArrowRight className="mt-1 ml-2" />
                        </button>
                     </div>
                  </article>
                  <article className="flex align-center ml-[25%] mt-[100px]">
                     <div className="flex-1 mx-2">
                        <p>Active Users</p>
                        <span className="font-bold text-xl">5000+</span>
                     </div>
                     <span className="w-0.5 opacity-20 bg-slate-500 ml-2">
                     </span>
                     <div className="flex-1 mx-2">
                        <p>Active Downloads</p>
                        <span className="font-bold text-xl">30.3k</span>
                     </div>
                     <span className="w-0.5   opacity-20 bg-slate-500">
                     </span>
                     <div className="flex-1 mx-2">
                        <p>Reviews</p>
                        <span className="font-bold text-xl">1200+</span>
                     </div>
                  </article>
               </div>
               { isSigUpWindowOpen && <Card className="md:w-2xl p-8 w-[30%] h-[85%] shadow-2xl rounded-lg ">
                  {<SignUpPage/>}
               </Card>}
                  <div className=" mt-[-10%] banner rounded-lg">
                     <Image src={stars} alt="Stars" height={100} width={100} />
                      <ul className="flex justify-end align-center mt-[-15%]">
                        <Button className="bg-[#030303] rounded-lg p-2 mr-5 font-bold text-white" onClick={() => setIsSigUpWindowOpen(true)} placeholder={"Sign Up"} >
                           Open your account
                        </Button>
                        <li>
                           <Button className="bg-white border-slate-300 rounded-lg p-2 font-bold text-black" onClick={() => setIsLoginWindowOpen(true)} placeholder={"Sign In"} >
                              Sign In
                           </Button>
                        </li>
                     </ul>
                  <Image src={hand} alt="Hand" className="rounded-lg m-auto " height={-10} width={450}/>
                    <div className="creditCard">
                     <Image src={creditCard} alt="credit card" />
                  </div>
                  </div>
                
               
            </section>
         </div>
        
         {isLoginWindowOpen && <LoginPage />}
      </>         
   )
}

Home.getLayout = (page:any)=>{
   return <RootLayout>{page}</RootLayout>
}
export default Home;