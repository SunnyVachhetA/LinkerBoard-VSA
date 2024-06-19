import { ToastContainer } from "react-toastify";
import Home from "./pages/Home";
import "react-toastify/dist/ReactToastify.css";

const App = () => {

  return (<>
    <Home />
    <ToastContainer />
  </>);

}

export default App;