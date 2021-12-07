import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import { readFileSync } from 'fs'
import { certFilePath, keyFilePath } from './aspnetcore-https'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  server: {
    https: {
      key: readFileSync(keyFilePath),
      cert: readFileSync(certFilePath)
    },
    port: 3000,
    strictPort: true,
    proxy: {
      '/api': {
        target: 'https://localhost:7085/',
        changeOrigin: true,
        secure: true
      }
    }
  }
})
