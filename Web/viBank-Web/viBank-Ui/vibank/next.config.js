/** @type {import('next').NextConfig} */
const nextConfig = {
  publicRuntimeConfig: {
    viBankUrl:
      process.env.APP_ENV === 'production'
        ? process.env.VIBANK_API_URL
        : 'http://localhost:5000'
  },
  experimental: {
    pages: {
      dir: 'src/pages'
    }
  }
}
module.exports = nextConfig
