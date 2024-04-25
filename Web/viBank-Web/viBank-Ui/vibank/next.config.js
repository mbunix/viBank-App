/** @type {import('next').NextConfig} */
const nextConfig = {
  pageExtensions: ['tsx'],
  webpack (config, options) {
    config.resolve.alias['pagesDir'] = path.join(
      __dirname,
      'Web/viBank-Web/viBank-Ui/vibank/src/pages/index.tsx'
    )
    return config
  }
}

export default nextConfig
