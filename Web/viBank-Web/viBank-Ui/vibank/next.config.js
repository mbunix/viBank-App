/** @type {import('next').NextConfig} */
const nextConfig = {
  output: 'export',

  publicRuntimeConfig: {
    viBankUrl:
      process.env.APP_ENV === 'production'
        ? process.env.VIBANK_API_URL
        : 'http://localhost:5000'
  },
  pageExtensions: ['tsx'],
  webpack (config, options) {
    config.resolve.alias['pagesDir'] = path.join(
      __dirname,
      'Web/viBank-Web/viBank-Ui/vibank/src/pages'
    )
    return config
  }
}
module.exports = nextConfig
