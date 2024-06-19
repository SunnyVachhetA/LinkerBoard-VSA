import Footer from "../components/Footer";
import Header from "../components/Header";
import LinkBoardPage from "./LinkBoardPage";

const Home = () => {
  return (<>
    <div className="flex flex-col min-h-screen">
      <Header />
      <main className="flex-1">
        <LinkBoardPage />
      </main>
      <Footer />
    </div>

  </>);
}

export default Home;