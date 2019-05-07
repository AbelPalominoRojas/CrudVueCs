# Crud con C# y Vue.js 2


### Pre-requisitos
[Node.js](https://nodejs.org/es/) minimo v6

### Crear el archivo manifiesto (package.json)
_crear el archivo en la raiz de la capa web_

```
npm init -y
``` 

### Configurar el archivo manifiesto (package.json)
_dependencias de la aplicacion_

```
"dependencies": {
    "@fortawesome/fontawesome-free": "^5.8.1",
    "axios": "^0.18.0",
    "bootstrap": "^4.3.1",
    "jquery": "^3.4.0",
    "moment": "^2.24.0",
    "popper.js": "^1.15.0",
    "vue": "^2.6.10",
    "vue-date-pick": "^1.1.0"
  }
``` 

_dependencias de desarrollo_

```
"devDependencies": {
    "@babel/core": "^7.4.4",
    "@babel/preset-env": "^7.4.4",
    "babel-loader": "^8.0.5",
    "browser-sync": "^2.26.5",
    "browser-sync-webpack-plugin": "^2.2.2",
    "copy-webpack-plugin": "^5.0.3",
    "css-loader": "^2.1.1",
    "file-loader": "^3.0.1",
    "mini-css-extract-plugin": "^0.6.0",
    "node-sass": "^4.12.0",
    "optimize-css-assets-webpack-plugin": "^5.0.1",
    "sass-loader": "^7.1.0",
    "style-loader": "^0.23.1",
    "uglifyjs-webpack-plugin": "^2.1.2",
    "vue-loader": "^15.7.0",
    "vue-style-loader": "^4.1.2",
    "vue-template-compiler": "^2.6.10",
    "webpack": "^4.30.0",
    "webpack-cli": "^3.3.1",
    "webpack-dev-server": "^3.3.1"
  }
``` 

_script de ejecucion_

```
"scripts": {
    "dev": "webpack --mode development --progress --hide-modules",
    "watch": "webpack --watch --mode development --progress --hide-modules",
    "prod": "webpack --mode production --no-progress --hide-modules"
  }
``` 

### Configuracion webpack (webpack.config.js)


```
﻿"use strict";

const webpack = require('webpack');
const  {VueLoaderPlugin} = require('vue-loader');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');
const OptimizeCSSAssetsPlugin = require('optimize-css-assets-webpack-plugin');
const CopyWebpackPlugin = require('copy-webpack-plugin');
const BrowserSyncPlugin = require('browser-sync-webpack-plugin')
const path = require("path");


module.exports={
  entry:{
    vendor:'./src/vendor.js',
    app:'./src/app.js'
  },
  output:{
    path:path.resolve(__dirname, 'dist'),
    filename:'./js/[name]-bundle.js'
  },
  optimization: {
    minimizer: [
      new UglifyJsPlugin({
        uglifyOptions: {
          output: {
            comments: false,
          },
        },
      }),
      new OptimizeCSSAssetsPlugin({
        cssProcessorPluginOptions: {
          preset: ['default', { discardComments: { removeAll: true } }],
        }
      })
    ],
  },
  module:{
    rules:[
        {
          test:/\.js$/,
          exclude:/node_modules/,
          use:{
            loader:'babel-loader'
          }
        },
        {
          test:/\.vue$/,
          loader:'vue-loader'
        },
        {
          test:/\.(sa|sc|c)ss$/,
          use:[
              {
                loader: MiniCssExtractPlugin.loader,
                options: {
                  hmr: process.env.NODE_ENV === 'development',
                }
              },
              {
                loader:'css-loader'
              },
              {
                loader: 'sass-loader',
                options: {
                  minimize: true
                }
              }
          ]
        },
        {
          test :/\.(png|jpg|gif|svg)$/,
          exclude:/node_modules/,
          loader:'file-loader',
          options:{
            name:'[name].[etx]?[hash]',
            outputPath: '../img'
          }

        },
        {
            test: /\.(woff(2)?|ttf|eot|svg)(\?v=\d+\.\d+\.\d+)?$/,
            use: [{
              loader: 'file-loader',
              options: {
                name: '[name].[ext]',
                outputPath: '/webfonts',
                publicPath: '../webfonts' 

              }
            }]
        }
    ]
  },
  resolve: {
    alias: {
      'vue$': 'vue/dist/vue.esm.js' // 'vue/dist/vue.common.js' for webpack 1
    },
    extensions:['*','.wasm', '.mjs','.js','.vue','.json'],
  },
  devServer:{
    contentBase: path.join(__dirname, 'dist'),
    compress: true,
    port: 9000
  },
  performance:{
    hints:false
  },
  devtool:'#eval-source-map',
  plugins:[
      new VueLoaderPlugin(),
      new MiniCssExtractPlugin({
        filename:'css/[name]-bundle.css',
        chunkFilename: '[id].css'
      }),
      new webpack.ProvidePlugin({
        $: 'jquery',
        jQuery: 'jquery'
      }),
      new CopyWebpackPlugin([{
        from: 'node_modules/@fortawesome/fontawesome-free/webfonts',
        to: 'webfonts/'
      }]),
      new BrowserSyncPlugin(
        // BrowserSync options
        {
          // browse to http://localhost:3000/ during development
          host: 'localhost',
          port: 3000,
          // proxy the Webpack Dev Server endpoint
          // (which should be serving on http://localhost:3100/)
          // through BrowserSync
          proxy: 'http://localhost:54330/',
          open: false
        }
      )
  ]  
};

``` 

### Crear el archivo babel y configurar (.babelrc)

```
{
    "presets": [
        "@babel/preset-env"
    ]
}
``` 