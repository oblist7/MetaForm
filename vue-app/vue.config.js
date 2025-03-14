const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: true,
  devServer: {
    proxy: {
      '/api': {
        target: 'http://localhost:5173',
        changeOrigin: true,
        secure: false
      }
    }
  },
  css: {
    extract: true
  }
  // configureWebpack: {
  //   output: {
  //     filename: 'js/app.js', // Single JS file for production
  //     chunkFilename: 'js/app.js'
  //   }
  // }
})
