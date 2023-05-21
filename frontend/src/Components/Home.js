import React from "react";
import RandomProducts from "./RandomProducts";
import {Search} from "./Search";

export function Home() {
  return (
    <>
      <Search />
      <RandomProducts />
    </>
  );
}
