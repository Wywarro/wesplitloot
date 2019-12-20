module.exports = {
  outputDir: '../backend/src/ClientApp/dist',
  "transpileDependencies": [
    "vuetify"
  ],
  configureWebpack: config => {
    config.watchOptions = {
      poll: true
    }
  }
}