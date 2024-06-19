const Header = () => {
  return (
    <>
      <header className="bg-gray-800 text-white p-4 flex justify-between items-center">
        <h1 className="text-2xl font-bold">Dashboard</h1>
        <div className="flex space-x-4">
          <button className="bg-blue-500 py-2 px-4 rounded">Refresh</button>
          <button className="bg-yellow-500 py-2 px-4 rounded">Profile</button>
        </div>
      </header>
    </>
  );
}

export default Header;