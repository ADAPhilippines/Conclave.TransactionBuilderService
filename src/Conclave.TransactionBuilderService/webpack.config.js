const path = require('path');
const webpack = require('webpack');

module.exports = {
  entry: './Interop.ts',
  devtool: 'inline-source-map',
  mode: 'development',
  context: path.resolve(__dirname, 'wwwroot/scripts'),
  plugins: [
    // Work around for Buffer is undefined:
    // https://github.com/webpack/changelog-v5/issues/10
    new webpack.ProvidePlugin({
      Buffer: ['buffer', 'Buffer'],
    }),
    new webpack.ProvidePlugin({
      process: 'process/browser',
    }),
  ],
  module: {
    rules: [
      {
        test: /\.tsx?$/,
        use: 'ts-loader',
        exclude: [/node_modules/],
      },
    ],
  },
  resolve: {
    extensions: ['.tsx', '.ts', '.js'],
    fallback: {
      "stream": require.resolve("stream-browserify"),
      "buffer": require.resolve("buffer")
    }
  },
  output: {
    filename: 'app.bundle.js',
    path: path.resolve(__dirname, 'wwwroot/dist'),
  },
};