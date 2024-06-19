const TopBar = () => {
  return (<>
    <div className="flex-1 flex flex-col overflow-hidden">
      <div className="bg-gray-200 p-4 flex items-center justify-between">
        <button
          className="bg-green-500 text-white py-2 px-4 rounded"
        >
          New Board
        </button>
        <input
          type="text"
          placeholder="Search"
          className="border p-2 rounded w-1/3"
        />
      </div>
    </div>
  </>);
}

export default TopBar;