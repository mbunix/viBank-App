/** @type {import('next').NextConfig} */
const nextConfig = {
  publicRuntimeConfig: {
    viBankUrl:
      process.env.APP_ENV === 'production'
        ? process.env.VIBANK_API_URL
        : process.env.VIBANK_API_URL ?? 'http://localhost:5000'
  },
  output: 'export',
  images: {
    unoptimized: true
  }
}
module.exports = nextConfig
