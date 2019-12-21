module.exports = {
  outputDir: '../wesplitlootapi/ClientApp/dist',
  "transpileDependencies": [
    "vuetify"
  ],
  configureWebpack: config => {
    config.watchOptions = {
      poll: true
    }
  }
}