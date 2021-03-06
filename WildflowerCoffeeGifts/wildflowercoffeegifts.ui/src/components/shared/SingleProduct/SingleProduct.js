import React from 'react';
import { Link } from 'react-router-dom';

import './SingleProduct.scss';

import PropTypes from 'prop-types';

import productShape from '../../../helpers/propz/productShape';

class SingleProduct extends React.Component {
  static propTypes = {
    authed: PropTypes.bool.isRequired,
    product: productShape.productShape,
  }

  render() {
    const { product, authed } = this.props;
    const singleProductLink = `/products/${product.id}`;
    return (
      <div className="col-md-4 p-1">
        <div className='card'>
          <div className='card-title'>
            <h6 className= "title mt-3">{product.title}</h6>
          </div>
          <img src={product.imageUrl} className= "productImage center card-img-top" alt="product"/>
          <div className="card-body text-center mb-2">
           <p>Price: ${product.price}</p>
           <p>Quantity Available: {product.quantityAvailable}</p>
           <div>
            <Link to={singleProductLink} className="wcgButton" product={product} productId={product.id} authed={authed}>View Details</Link>
           </div>
         </div>
          </div>
        </div>
    );
  }
}
export default SingleProduct;
