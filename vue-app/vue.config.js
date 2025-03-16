const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: true,
  devServer: {
    proxy: {
      '/api': {
        target: 'http://backend:5173',
        changeOrigin: true,
        secure: false
      }
    }
  },
  css: {
    extract: true
  }
})
