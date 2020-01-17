import { EmptyLayout, LayoutRoute, MainLayout } from '../src/components/Layout';
import React from 'react';
import { BrowserRouter, Redirect, Route, Switch } from 'react-router-dom';
import './styles/reduction.scss';
import CardPage from 'pages/CardPage'
import ChartPage from 'pages/ChartPage'
import DashboardPage from 'pages/DashboardPage'
import WidgetPage from 'pages/WidgetPage'




class App extends React.Component {
  render() {
    return (
      <BrowserRouter>
          <Switch>
            <MainLayout breakpoint={this.props.breakpoint}>
                <Route exact path="/" component={DashboardPage} />
                <Route exact path="/cards" component={CardPage} />
                <Route exact path="/widgets" component={WidgetPage} />
                <Route exact path="/charts" component={ChartPage} />
            </MainLayout>
            <Redirect to="/" />
          </Switch>
      </BrowserRouter>
    );
  }
}


export default App;
